import React, { useState, useEffect } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { AppDispatch } from '../../../app/store';
import Board from '../../kanban/Board/Board';
import { DragDropContext } from "react-beautiful-dnd";
import { v4 as uuidv4 } from "uuid";
import Editable from "../../kanban/Editable/Editable";
import { addBoard, fetchAllBoards } from './tasksPageSlice';
import { useParams } from 'react-router-dom';

function TasksPage() {
    const [data, setData]: any = useState([]);
    const dispatch = useDispatch<AppDispatch>();
    const { company }  = useParams<string>();
    const nextOrderValue = useSelector((x: any) => x.tasks.boards.entities.length + 1);
    const boards = useSelector((x: any) => x.tasks.boards.entities);
    const cards = useSelector((x: any) => x.tasks.cards.entities);

    useEffect(() => {
        if (boards.length == 0) dispatch(fetchAllBoards(company));
    });

    const setName = (title: any, bid: any) => {
        const index = data.findIndex((item: any) => item.id === bid);
        const tempData : any = [...data];
        tempData[index].boardName = title;
        setData(tempData);
    };

    const dragCardInBoard = (source: any, destination: any) => {
        let tempData: any = [...data];
        const destinationBoardIdx = tempData.findIndex(
            (item: any) => item.id.toString() === destination.droppableId
        );
        const sourceBoardIdx = tempData.findIndex(
            (item: any) => item.id.toString() === source.droppableId
        );
        tempData[destinationBoardIdx].card.splice(
            destination.index,
            0,
            tempData[sourceBoardIdx].card[source.index]
        );
        tempData[sourceBoardIdx].card.splice(source.index, 1);

        return tempData;
    };

    const addCard = async (title: any, bid: any) => {
        const index = data.findIndex((item: any) => item.id === bid);
        const tempData: any = [...data];
        tempData[index].card.push({
            id: uuidv4(),
            title: title,
            tags: [],
            task: [],
        });
        setData(tempData);

    };

    const removeCard = (boardId: any, cardId: any) => {
        const index = data.findIndex((item: any) => item.id === boardId);
        const tempData: any = [...data];
        const cardIndex = data[index].card.findIndex((item: any) => item.id === cardId);

        tempData[index].card.splice(cardIndex, 1);
        setData(tempData);
    };

    const addBoardHandler = (title: any) => {
        const board = {
            title: title,
            order: nextOrderValue,
            company,
            cards: []
        };
        dispatch(addBoard(board));
    };

    const removeBoard = (bid: any) => {
        const tempData: any = [...data];
        const index = data.findIndex((item: any) => item.id === bid);
        tempData.splice(index, 1);
        setData(tempData);
    };

    const onDragEnd = (result: any) => {
        const { source, destination } = result;
        if (!destination) return;

        if (source.droppableId === destination.droppableId) return;

        setData(dragCardInBoard(source, destination));
    };

    const updateCard = (bid: any, cid: any, card: any) => {
        const index = data.findIndex((item: any) => item.id === bid);
        if (index < 0) return;

        const tempBoards: any = [...data];
        const cards = tempBoards[index].card;

        const cardIndex = cards.findIndex((item: any) => item.id === cid);
        if (cardIndex < 0) return;

        tempBoards[index].card[cardIndex] = card;
        console.log(tempBoards);
        setData(tempBoards);
    };
  return (
      <DragDropContext onDragEnd={onDragEnd}>
          <div className="App">
              <div className="app_outer">
                  <div className="app_boards">
                      {boards.map((item: any) => {

                          const itemCards = item.cards.map((el: any) => cards[el.id]);

                          return (

                              <Board
                                  key={item.id ?? item.title}
                                  id={item.id ?? item.title}
                                  name={item.title}
                                  card={itemCards}
                                  setName={setName}
                                  addCard={addCard}
                                  removeCard={removeCard}
                                  removeBoard={removeBoard}
                                  updateCard={updateCard}
                              />
                          )

                      })}
                      <Editable
                          class={"add__board"}
                          name={"Add Board"}
                          btnName={"Add Board"}
                          onSubmit={addBoardHandler}
                          placeholder={"Enter Board  Title"}
                      />
                  </div>
              </div>
          </div>
      </DragDropContext>
  );
}

export default TasksPage;