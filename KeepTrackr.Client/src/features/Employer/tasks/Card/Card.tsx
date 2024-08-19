import React, { useState } from "react";
import { Draggable } from "react-beautiful-dnd";
import { Calendar, CheckSquare, Clock, MoreHorizontal } from "react-feather";
import Dropdown from "../Dropdown/Dropdown";
import Modal from "../Modal/Modal";
import Tag from "../Tags/Tag";
import "./Card.css";
import CardDetails from "../CardDetails/CardDetails";
import { openCard } from '../tasksPageSlice';
import { useDispatch } from "react-redux";
import { AppDispatch } from '../../../../app/store';
import { useSelector } from "react-redux";

const Card = (props: any) => {
    const [dropdown, setDropdown] = useState(false);
    const [modalShow, setModalShow] = useState(false);

    const labels = useSelector((x: any) => x.tasks.labels.entities.filter((c: any) => c.cardId == props.id));
    const card = useSelector((x: any) => x.tasks.cards.entities.find((c: any) => c.id == props.id));

    const dispatch = useDispatch<AppDispatch>();

    return (
        <Draggable
            key={props.id.toString()}
            draggableId={props.id.toString()}
            index={props.index}
        >

            {(provided: any) => (
                <>
                    <div
                        className="custom__card"
                        onClick={() => {
                            setModalShow(true);
                        }}
                        {...provided.draggableProps}
                        {...provided.dragHandleProps}
                        ref={provided.innerRef}
                    >
                        <div className="card__text">

                            <p>{ card.name }</p>
                            <MoreHorizontal
                                className="car__more"
                                onClick={() => {
                                    dispatch(openCard(props.id.toString()));
                                }}
                            />

                        </div>

                        <div className="card__tags">
                            {labels.map((item: any, index: any) => (
                                <Tag key={index} tagName={item.name} color={item.color} />
                            ))}
                        </div>

                        <div className="card__footer">
                            <div className="time">
                                <Clock />
                                <span>{card.completionDate}</span>
                            </div>
                            {/*{props.card.task.length !== 0 && (*/}
                            {/*    <div className="task">*/}
                            {/*        <CheckSquare />*/}
                            {/*        <span>*/}
                            {/*            {props.card.task.length !== 0*/}
                            {/*                ? `${(props.card.task?.filter(*/}
                            {/*                    (item: any) => item.completed === true*/}
                            {/*                )).length*/}
                            {/*                } / ${props.card.task.length}`*/}
                            {/*                : `${"0/0"}`}*/}
                            {/*        </span>*/}
                            {/*    </div>*/}
                            {/*)}*/}
                        </div>

                        {provided.placeholder}
                    </div>
                </>
            )}
        </Draggable>
    );
};

export default Card;
